using Xamarin.Forms;

namespace PlasmaFinder.Effects
{
	public class TouchEffect : RoutingEffect
	{
		public Color BackgroundColor { get; set; }
		public Color TapBackgroundColor { get; set; }
		public TouchEffect() : base("PlasmaFinder.TouchEffect")
		{
		}
	}
}
