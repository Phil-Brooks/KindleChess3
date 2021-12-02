namespace FsChess.Pgn

module Games =

    ///Get a list of Games from a file
    let ReadListFromFile = FsChessPgn.Games.ReadFromFile
    
    ///Get a list of index * Game from a file
    let ReadIndexListFromFile = FsChessPgn.Games.ReadIndexListFromFile

    ///Get a Sequence of Games from a file
    let ReadSeqFromFile = FsChessPgn.Games.ReadSeqFromFile

    ///Write a list of Games to a file
    let WriteFile = FsChessPgn.PgnWriter.WriteFile


module Stats =

    ///Get Statistics for the Board
    let Get = FsChessPgn.Stats.Get
