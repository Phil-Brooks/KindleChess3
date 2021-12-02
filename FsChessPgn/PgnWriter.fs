namespace FsChessPgn

open FsChess
open System.IO

module PgnWriter =

    let WriteFile (file:string) (pgnGame:Game) =
        let stream = new FileStream(file, FileMode.Create)
        use writer = new StreamWriter(stream)
        PgnWrite.Game(pgnGame, writer)
        writer.WriteLine()
 