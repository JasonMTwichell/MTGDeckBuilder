using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.MTGJson.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.Mapping
{
    internal static class MetaMapper
    {
        public static ParsedMeta MapToParsedMeta(MTGJsonMeta deserializedMeta)
        {
            return new ParsedMeta
            {
                Date = deserializedMeta.Data.Date,
                Version = deserializedMeta.Data.Version
            };
        }
    }
}
