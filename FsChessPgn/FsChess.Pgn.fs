namespace FsChess.Pgn

module Game =

    ///Get Game from a file
    let ReadFromFile = FsChessPgn.RegParse.ReadGame

    ///Write a Game to a file
    let WriteFile = FsChessPgn.PgnWriter.WriteFile


module Stats =

    ///Get Statistics for the Board
    let Get = FsChessPgn.Stats.Get
