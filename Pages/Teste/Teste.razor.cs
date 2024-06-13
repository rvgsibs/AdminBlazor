using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AdminBlazor.Pages.Teste;

public partial class CreateTestePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public TesteRequest InputMode { get; set; } = new();
    public string msg { get; set; } = "Aqui vai a mensagem";

    #endregion

    #region Services

    //Todos os serviços tem que ter inject
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            Snackbar.Add("Aqui vai a mensagem", Severity.Success);
            Snackbar.Add("Error", Severity.Error);
            NavigationManager.NavigateTo("/contador");
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }

    }

    #endregion

    public class TesteRequest
    {
        [Required(ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }
    }
}
