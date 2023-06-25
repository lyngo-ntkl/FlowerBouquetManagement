using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FlowerBouquetManagementSystem.SignalR
{
    public class FlowerHub: Hub
    {
        public async Task LoadFlowerBouquet()
        {
            await Clients.All.SendAsync("LoadFlowerBouquet");
        }
    }
}
