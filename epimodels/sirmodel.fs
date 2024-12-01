namespace epimodels 
open Plotly.NET

module public sirSimulator =
    let public simulateSIR (beta: double) (gamma: double) (S0: double) (I0: double) (R0: double) (N: double) (steps: int) (dt: double) =
        let mutable S, I, R = S0, I0, R0
        let results = ResizeArray<double * double * double>()

        for _ in 1..steps do
            let newS = S - (beta * S * I / N) * dt
            let newI = I + (beta * S * I / N - gamma * I) * dt
            let newR = R + (gamma * I) * dt

            S <- newS
            I <- newI
            R <- newR

            results.Add((S, I, R))
        results

    let public runSimulationAndPlot () =
        // Parameters for the simulation
        let beta = 0.2       // Infection rate
        let gamma = 0.2      // Recovery rate
        let S0 = 999.0       // Initial susceptible population
        let I0 = 1.0         // Initial infected population
        let R0 = 0.0         // Initial recovered population
        let N = 100.0       // Total population
        let steps = 200      // Simulation steps
        let dt = 0.2         // Time step

        // Run the simulation
        let results = simulateSIR beta gamma S0 I0 R0 N steps dt

        // Extract values for plotting
        let time = [ for t in 0..steps -> float t * dt ]
        let sValues = [ for (s, _, _) in results -> s ]
        let iValues = [ for (_, i, _) in results -> i ]
        let rValues = [ for (_, _, r) in results -> r ]

        printfn "%f" beta

        // Print first few results for verification
        printfn "First few results:"
        results
        |> Seq.take 10
        |> Seq.iter (fun (s, i, r) -> printfn "S: %f, I: %f, R: %f" s i r)

        // Plot the results (optional)
        let chart =
            let sLine = Chart.Line(time, sValues, Name = "Susceptible")
            let iLine =  Chart.Line(time, iValues, Name = "Infected")
            let rLine = Chart.Line(time, rValues, Name = "Recovered")
            
            let combinedChart = Chart.combine [sLine; iLine; rLine]            
            combinedChart 
            |> Chart.withXAxisStyle(TitleText= "Time")
            |> Chart.withYAxisStyle(TitleText= "Population")

                
            
        
        GenericChart.toChartHTML chart
        

