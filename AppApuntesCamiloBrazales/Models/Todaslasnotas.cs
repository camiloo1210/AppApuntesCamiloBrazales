using AppApuntesCamiloBrazales.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppApuntesCamiloBrazales.Models
{
	internal class Todaslasnotas
    {
		public ObservableCollection<Notas> Note { get; set; } = new ObservableCollection<Notas>();
		public Todaslasnotas() =>
		  CargarNotas();

		public void CargarNotas()
		{
			Note.Clear();

			// Get the folder where the notes are stored.
			string appDataPath = FileSystem.AppDataDirectory;

			// Use Linq extensions to load the *.notes.txt files.
			IEnumerable<Notas> notes = Directory

								// Select the file names from the directory
										.EnumerateFiles(appDataPath, "*.notes.txt")

										// Each file name is used to create a new Note
										.Select(filename => new Notas()
										{
											Filename = filename,
											Text = File.ReadAllText(filename),
											Date = File.GetLastWriteTime(filename)
										})

										// With the final collection of notes, order them by date
										.OrderBy(note => note.Date);

			// Add each note into the ObservableCollection
			foreach (Notas note in notes)
				Note.Add(note);
		}
	}
}

