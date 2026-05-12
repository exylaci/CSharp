using ASPdotNETcalculator.MAUI.Dtos;
using ASPdotNETcalculator.MAUI.Services.Interfaces;

namespace ASPdotNETcalculator.MAUI.Services.Models;

public class OperationService : IOperationService
{

    public async Task<Response> Addition(Question question)
    {
        return MegNemTudokSzamolni();
    }

    public async Task<Response> Substraction(Question question)
    {
        return MegNemTudokSzamolni();
    }

    public async Task<Response> Multiplication(Question question)
    {
        return MegNemTudokSzamolni();
    }

    public async Task<Response> Division(Question question)
    {
        return MegNemTudokSzamolni();
    }

    public async Task Store(Store store)
    {
    }

    public async Task<Response> Recall()
    {
        return MegNemTudokSzamolni();
    }

    public async Task MemoryClear()
    {
        await Task.CompletedTask;
    }


    private Response MegNemTudokSzamolni()
    {
        //TODO  Ezt a függvényt majd ha már a backenddel számoltatok, törölnöm kell!!!

        Response response = new Response();
        response.ErrorMessage = "Még nem tudok számolni";
        response.Result = -1;
        return response;
    }
}