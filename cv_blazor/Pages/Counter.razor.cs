using Microsoft.AspNetCore.Components;
using cv.Services;

namespace cv.Components
{
    public partial class Publications: ComponentBase
    {
        List<Publication> publicationList = new();
        private string? ExpandedAbstract;
        
        // Inject the PublicationService via DI
        [Inject] 
        public PublicationService PublicationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Fetch publications asynchronously using the injected service
            publicationList = await PublicationService.GetPublicationsAsync();
        }
   
        private void ToggleAbstract(string title)
        {
            ExpandedAbstract = ExpandedAbstract == title ? null : title;
        }
    }
}