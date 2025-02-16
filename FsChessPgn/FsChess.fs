﻿namespace FsChess

module GameDate =

    ///Gets the string symbol for a Piece
    let ToStr = FsChessPgn.DateUtil.ToStr


module Result =

    ///Gets the string symbol for a Piece
    let ToStr = FsChessPgn.GameResult.ToStr

    ///Gets the string symbol for a Piece
    let ToUnicode = FsChessPgn.GameResult.ToUnicode

module Square =

    ///Gets the File for a Square
    let ToFile = FsChessPgn.Square.ToFile

    ///Gets the Rank for a Square
    let ToRank = FsChessPgn.Square.ToRank

    ///Gets the Name for a Square
    let Name = FsChessPgn.Square.Name

module Piece =

    ///Gets the string symbol for a Piece
    let ToStr = FsChessPgn.Piece.PieceToString

    ///Gets the player for a Piece
    let ToPlayer = FsChessPgn.Piece.PieceToPlayer

module Board =

    ///Create a new Board given a FEN string
    let FromStr = FsChessPgn.Board.FromStr
    
    ///Create a FEN string from this Board 
    let ToStr = FsChessPgn.Board.ToStr

    ///The starting Board at the beginning of a game
    let Start = FsChessPgn.Board.Start

    ///Gets all legal moves for this Board
    let AllMoves = FsChessPgn.MoveGenerate.AllMoves

    ///Gets all possible moves for this Board from the specified Square
    let PossMoves = FsChessPgn.MoveGenerate.PossMoves

    ///Make an encoded Move for this Board and return the new Board
    let Push = FsChessPgn.Board.MoveApply

    ///Is there a check on the Board
    let IsCheck = FsChessPgn.Board.IsChk
    
    ///Is the current position on the Board checkmate?
    let IsCheckMate = FsChessPgn.MoveGenerate.IsMate 

    ///Is the current position on the Board stalemate?
    let IsStaleMate = FsChessPgn.MoveGenerate.IsDrawByStalemate 

    ///Is the Square attacked by the specified Player for this Board
    let SquareAttacked = FsChessPgn.Board.SquareAttacked
    
    ///The Squares that attack the specified Square by the specified Player for this Board
    let SquareAttackers = FsChessPgn.Board.SquareAttacksTo

    ///Creates a PNG image with specified name, flipped if specified for the given Board 
    let ToPng = FsChessPgn.Png.BoardToPng

    ///Prints an ASCII version of this Board 
    let Print = FsChessPgn.Board.PrintAscii

module Move =

    ///Get the source Square for an encoded Move
    let From = FsChessPgn.Move.From

    ///Get the target Square for an encoded Move
    let To = FsChessPgn.Move.To

    ///Get the promoted PieceType for an encoded Move
    let PromPcTp = FsChessPgn.Move.PromoteType

    ///Get the pMove for a move for this board
    let TopMove = FsChessPgn.MoveUtil.topMove

module Game =

    ///The starting Game with no moves
    let Start = FsChessPgn.Game.Start

    ///Gets a single move as a string given one of the list from Game.MoveText
    let MoveStr = FsChessPgn.PgnWrite.MoveTextEntryStr

    ///Gets a NAG as a string such as ?? given one of the list from Game.MoveText
    let NAGStr = FsChessPgn.NagUtil.ToStr

    ///Gets a NAG from a string such as ?? 
    let NAGFromStr = FsChessPgn.NagUtil.FromStr

    ///Gets a NAG as HTML such as ?? given one of the list from Game.MoveText
    let NAGHtm = FsChessPgn.NagUtil.ToHtm

    ///Gets a NAG as a description such as Very Good given one of the list from Game.MoveText
    let NAGDesc = FsChessPgn.NagUtil.Desc

    ///Gets a list of all NAGs supported
    let NAGlist = FsChessPgn.NagUtil.All

    //Adds a Nag in the Game after the address provided
    let AddNag = FsChessPgn.Game.AddNag

    //Deletes a Nag in the Game at the address provided
    let DeleteNag = FsChessPgn.Game.DeleteNag

    //Edits a Nag in the Game at the address provided
    let EditNag = FsChessPgn.Game.EditNag

    ///Gets the moves text as a string given the Game.MoveText
    let MovesStr = FsChessPgn.PgnWrite.MoveTextStr

    //Gets the aMoves for the Game
    let GetaMoves = FsChessPgn.Game.SetaMoves

    //Adds a pMove to the Game given its address
    let AddMv = FsChessPgn.Game.AddMv

    //Adds a RAV to the Game given the pMove is contains and its address
    let AddRav = FsChessPgn.Game.AddRav

    //Deletes a RAV in the Game at the address provided
    let DeleteRav = FsChessPgn.Game.DeleteRav

    //Adds a comment to the Game before the address provided
    let CommentBefore = FsChessPgn.Game.CommentBefore

    //Adds a comment to the Game after the address provided
    let CommentAfter = FsChessPgn.Game.CommentAfter

    //Edits a comment to the Game at the address provided
    let EditComment = FsChessPgn.Game.EditComment

    //Deletes a comment in the Game at the address provided
    let DeleteComment = FsChessPgn.Game.DeleteComment

module IO =

    ///Get Game from a file
    let ReadFromFile = FsChessPgn.RegParse.ReadGame

    ///Write a Game to a file
    let WriteFile = FsChessPgn.PgnWriter.WriteFile

