namespace AppApuntesCamiloBrazales.Views;

public partial class ListaNotas : ContentPage
{
	public ListaNotas()
	{
		InitializeComponent();
		BindingContext = new Models.Todaslasnotas();
	}
	protected override void OnAppearing()
	{
		((Models.Todaslasnotas)BindingContext).CargarNotas();
	}

	private async void Add_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(Notas));
	}

	private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count != 0)
		{
			// Get the note model
			var note = (Models.Notas)e.CurrentSelection[0];

			// Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
			await Shell.Current.GoToAsync($"{nameof(PaginaNotas)}?{nameof(PaginaNotas.ItemId)}={note.Filename}");

			// Unselect the UI
			notesCollection.SelectedItem = null;
		}
	}
}