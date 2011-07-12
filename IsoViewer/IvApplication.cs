using Ps.Win.Controls;

namespace Ps.Iso.Viewer {
	public class IvApplication : MultiSDIApplication<IvApplication,IsoFileForm>{
    public override string Name { get { return "ISO Viewer"; } }
	}
}