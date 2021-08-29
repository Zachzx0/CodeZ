using System.IO;

namespace CodeZ.Core
{
    internal interface ISerializable
    {
        void WriteTo(MemoryStream stream);

        void ReadFrom(MemoryStream stream);
    }
}