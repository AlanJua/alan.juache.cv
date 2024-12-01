using System;
using epimodels;
namespace cv.Services
{
    public class ModelsSIRPlot{
        
        public async Task<ModelSIR> GetPlotContentDiv()
        {
            string divContent = epimodels.sirSimulator.runSimulationAndPlot();
            return new ModelSIR
            {
                div = divContent
            };
        }

    public class ModelSIR {
        public string? div {get; set;}
    }
}}