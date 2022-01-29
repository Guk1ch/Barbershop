
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Barbershop.MyClasses
{
    public partial class Service
    {
        public int IdService { get; set; }
        public int IdTypeService { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageInByte { get; set; }
        public string Description { get; set; }

        public string NameTypeService
        {
            get => GetNameTypeService();
        }

        public string GetNameTypeService()
        {
            return Task.Run(async () => await TypeServiceService.GetServices()).Result.FirstOrDefault(obj => obj.IdTypeService == IdTypeService).Name;
        }
        public ImageSource GetImage
        {
            get => ImageSource.FromStream(() => new MemoryStream(ImageInByte));
        }
    }
}