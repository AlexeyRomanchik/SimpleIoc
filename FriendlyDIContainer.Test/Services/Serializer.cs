using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class Serializer : ISerializer
    {
        public void Deserialize()
        {
            Console.WriteLine("Deserialize");
        }

        public void Serialize()
        {
            Console.WriteLine("Serialize");
        }
    }
}
