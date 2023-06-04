using System.Threading.Tasks;
using Militaria.Gus;
using ReactiveUI;

namespace Militaria.WPF.ViewModels
{
    public class MainWindowViewModel : ReactiveUI.ReactiveObject
	{

		private AreaClass[] _dane = new AreaClass[0];
		
		public AreaClass[] Dane //właściwość
		{
			get { return _dane; }
			set { this.RaiseAndSetIfChanged(ref _dane, value); }
		}
        public MainWindowViewModel()
        {
			Task.Run(() => UstawianieDanych());
        }
		private async Task UstawianieDanych()
		{
            AreaClass[] res = await GusApiProcess.GetEndPoint();
            Dane = res;
        }

    }
}
