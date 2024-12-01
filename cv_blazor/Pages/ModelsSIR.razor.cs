// using epimodels;
// using Microsoft.AspNetCore.Components;
// using Plotly.NET;
// using cv.Services;


// namespace cv.Components
// {
//     public partial class ModelsSIR : ComponentBase
//     {
//         public string? plotContentDivString;
//         public ModelsSIRPlot.ModelSIR plotContentDiv;

//         [Inject]
//         ModelsSIRPlot ModelsSIRPlot { get; set; } = default!;
//         protected override async Task OnInitializedAsync()
//             {
//                 try 
//             {
//                 plotContentDiv = await ModelsSIRPlot.GetPlotContentDiv();
//                 plotContentDivString = plotContentDiv?.div;

//                 // Add diagnostic logging
//                 Console.WriteLine($"PlotContentDiv: {plotContentDiv}");
//                 Console.WriteLine($"PlotContentDivString: {plotContentDivString}");
//             }
//             catch (Exception ex)
//             {
//                 // Log any exceptions
//                 Console.WriteLine($"Error in OnInitializedAsync: {ex.Message}");
//                 plotContentDivString = $"Error: {ex.Message}";
//             }
//                 // plotContentDiv = await ModelsSIRPlot.GetPlotContentDiv();
//                 // plotContentDivString = plotContentDiv?.div;
                
//             }
//     }
// }



