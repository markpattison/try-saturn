open Saturn
open Giraffe

type Operation = Double | Triple
type Result =
    { Input: int
      Operation: Operation
      Answer: int
    }

let doubler x = { Input = x; Operation = Double; Answer = x * 2 }
let tripler x = { Input = x; Operation = Triple; Answer = x * 3 }

let doubleController = controller {
    show (fun ctx id -> id |> doubler |> Controller.json ctx)
}

let tripleController = controller {
    show (fun ctx id -> id |> tripler |> Controller.json ctx)
}

let appRouter = router {
    not_found_handler (text "Page not found")
    get "/blah" (text "BLAH 1")
    forward "/double" doubleController
    forward "/triple" tripleController
}

let app = application {
    use_router appRouter
}

run app
