
using System.Linq;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public int IdService { get; set; }
        public System.DateTime DateOfCompletion { get; set; }
        public bool Done { get; set; }
    }
}