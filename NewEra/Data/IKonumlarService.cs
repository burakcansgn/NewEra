using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewEra.Data
{
    // Each item below provides an interface to a method in KonumlarServices.cs
    public interface IKonumlarService
    {
        Task<bool> KonumlarInsert(Konumlar konumlar);
        Task<IEnumerable<Konumlar>> KonumlarGetAll();
        Task<Konumlar> Konumlar_GetOne(int ID);
        Task<bool> KonumlarUpdate(Konumlar konumlar);
        Task<bool> KonumlarDelete(int ID);
    }
}