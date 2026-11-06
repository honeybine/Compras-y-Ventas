using Common.Attributes;
using System.Collections.Generic;

namespace Common.Interfaces {
    public interface ICrud {
        void Create(AttributeBaseClass attributes);

        AttributeBaseClass Read(int id);
        List<AttributeBaseClass>    ReadWithPage(int page);
        List<AttributeBaseClass>    ReadWhereColumnWithPage(string column, string value, int page);
        List<AttributeBaseClass>    ReadFromColumnWithPage(string column, int page);

        void Update(int id, AttributeBaseClass attributes);
        void Delete(int id);
    }
}