namespace FsChessPgn

open FsChess
open System.Text

module MoveUtil = 
    
    let topMove (board : Brd) (move : Move) = 
        let piece = board.PieceAt.[int(move|>Move.From)]
        let pct = piece|>Piece.ToPieceType
        let fromrank = move|>Move.From|>Square.ToRank
        let fromfile = move|>Move.From|>Square.ToFile
        let pcprom = move|>Move.Promote
        let isprom = pcprom <> Piece.EMPTY
        let ptprom = pcprom|>Piece.ToPieceType
        let sTo = move|>Move.To
        let sFrom = move|>Move.From
    
        let iscap = 
            if (sTo = board.EnPassant && (piece = Piece.WPawn || piece = Piece.BPawn)) then true
            else board.PieceAt.[int(sTo)] <> Piece.EMPTY

        let nbd = board|>Board.MoveApply(move)
        let ischk = nbd|>Board.IsChk
        let ismt = nbd|>MoveGenerate.IsMate

    
        if piece = Piece.WKing && sFrom = E1 && sTo = G1 then 
            pMove.CreateCastle(MoveType.CastleKingSide)
        elif piece = Piece.BKing && sFrom = E8 && sTo = G8 then 
            pMove.CreateCastle(MoveType.CastleKingSide)
        elif piece = Piece.WKing && sFrom = E1 && sTo = C1 then 
            pMove.CreateCastle(MoveType.CastleQueenSide)
        elif piece = Piece.BKing && sFrom = E8 && sTo = C8 then 
            pMove.CreateCastle(MoveType.CastleQueenSide)
        else 
            //do not need this check for pawn moves
            let rec getuniqs pu fu ru attl = 
                if List.isEmpty attl then pu, fu, ru
                else 
                    let att = attl.Head
                    if att = sFrom then getuniqs pu fu ru attl.Tail
                    else 
                        let otherpiece = board.PieceAt.[int(att)]
                        if otherpiece = piece then 
                            let npu = false
                            let nru = 
                                if (att|>Square.ToRank) = fromrank then false
                                else ru
                        
                            let nfu = 
                                if (att|>Square.ToFile) = fromfile then false
                                else fu
                        
                            getuniqs npu nfu nru attl.Tail
                        else getuniqs pu fu ru attl.Tail
        
            let pu, fu, ru = 
                if ((piece=Piece.WPawn)||(piece=Piece.BPawn)) then
                    if iscap then false,true,false else true,true,true
                else getuniqs true true true ((board|>Board.AttacksTo sTo (piece|>Piece.PieceToPlayer))|>Bitboard.ToSquares)

            let uf,ur =
                if pu then None,None
                else
                    if fu then Some(fromfile), None
                    elif ru then None,Some(fromrank)
                    else Some(fromfile),Some(fromrank)
            let mt = if iscap then MoveType.Capture else MoveType.Simple
            pMove.CreateAll(mt,sTo,Some(pct),uf,ur,(if isprom then Some(ptprom) else None),ischk,false,ismt)

    ///Get an encoded move from a SAN Move(move) such as Nf3 for this Board(bd)
    let fromSAN (bd : Brd) (move : string) = 
        let pmv = move|>pMove.Parse
        let mv = pmv|>pMove.ToMove bd
        mv
