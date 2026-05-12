using ASPdotNETcalculator.MAUI.Dtos;
using ASPdotNETcalculator.MAUI.Services.Interfaces;

namespace ASPdotNETcalculator.MAUI.ViewModels;

public class CalculatorViewModel : BaseViewModel
{
    private readonly IOperationService _operationService;

    private double _a;
    private double _b;
    private double _result;
    
    public Command AdditionCommand { get; set; }
    public Command SubstractionCommand { get; set; }
    public Command MultiplicationCommand { get; set; }
    public Command DivisionCommand { get; set; }
    public Command MemoryStoreCommand { get; set; }
    public Command MemoryRecallCommand { get; set; }
    public Command MemoryClearCommand { get; set; }

    public double A
    {
        get => _a;
        set => SetField(ref _a, value);
    }

    public double B
    {
        get => _b;
        set => SetField(ref _b, value);
    }
    public double Result
    {
        get => _result;
        set => SetField(ref _result, value);
    }

    public CalculatorViewModel(IOperationService operationService)
    {
        _operationService = operationService;
        PageTitle = "Számológép";
        AdditionCommand = new Command(async () => await AdditionAsync());
        SubstractionCommand = new Command(async () => await SubstractionAsync());
        MultiplicationCommand = new Command(async () => await MultiplicationAsync());
        DivisionCommand = new Command(async () => await DivisionAsync());
        MemoryStoreCommand = new Command(async () => await StoreAsync());
        MemoryRecallCommand = new Command(async () => await RecallAsync());
        MemoryClearCommand = new Command(async () => await MemoryClearAsync());
    }

    private async Task AdditionAsync()
    {
        Question question = new Question();
        question.A = A;
        question.B = B;
        Response? response = await _operationService.Addition(question);
        if (response is null)
        {
            ErrorMessage = "Valami hiba történt, nem érkezett válasz.";
            return;
        }

        Result = response.Result;
        ErrorMessage = response.ErrorMessage;
    }

    private async Task SubstractionAsync()
    {
        Question question = new Question();
        question.A = A;
        question.B = B;
        Response? response = await _operationService.Substraction(question);
        if (response is null)
        {
            ErrorMessage = "Valami hiba történt, nem érkezett válasz.";
            return;
        }

        Result = response.Result;
        ErrorMessage = response.ErrorMessage;
    }

    private async Task MultiplicationAsync()
    {
        Question question = new Question();
        question.A = A;
        question.B = B;
        Response? response = await _operationService.Multiplication(question);
        if (response is null)
        {
            ErrorMessage = "Valami hiba történt, nem érkezett válasz.";
            return;
        }

        Result = response.Result;
        ErrorMessage = response.ErrorMessage;
    }

    private async Task DivisionAsync()
    {
        Question question = new Question();
        question.A = A;
        question.B = B;
        Response? response = await _operationService.Division(question);
        if (response is null)
        {
            ErrorMessage = "Valami hiba történt, nem érkezett válasz.";
            return;
        }

        Result = response.Result;
        ErrorMessage = response.ErrorMessage;
    }

    private async Task StoreAsync()
    {
        Store store = new Store();
        store.A = A;
        await _operationService.Store(store);
        ErrorMessage = "Eltároltam.";
    }

    private async Task RecallAsync()
    {
        Response? response = await _operationService.Recall();
        if (response is null)
        {
            ErrorMessage = "Valami hiba történt, nem érkezett válasz.";
            return;
        }

        B = response.Result;
        ErrorMessage = response.ErrorMessage;
    }

    private async Task MemoryClearAsync()
    {
        await _operationService.MemoryClear();
        ErrorMessage = "Töröltem a memóriát.";
    }
}