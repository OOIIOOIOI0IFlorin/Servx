using Microsoft.AspNetCore.Components;
using Servx.Models;
using Servx.Services;

namespace Servx.Pages
{
    public partial class Reservation
    {
        [Inject] protected ReservationService _reservationService { get; set; } = default!;

        private string Message { get; set; } = string.Empty;
        private ResevationModel resevationModelForm = new();


        private async Task Submit()
        {
            var result = await _reservationService.PostAsync(resevationModelForm);
            if (result.Success) 
            {
                Message = "Programarea in service s-a efectuat cu success si vei fi contactat telefonic in scurt timp pentru confirmare.";
                resevationModelForm = new();
            }
            else 
            {
                Message = result.Message;
            }

            await InvokeAsync(StateHasChanged);
        }
    }
}
