// Adapted to C# from:
// https://github.com/elimisteve/go.tent/blob/master/tent/constants.go

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TentLib
{
    public static class InfoTypes
    {
        public const string TYPE_CORE_V0_1_0 = "https://tent.io/types/info/core/v0.1.0";
        public const string TYPE_BASIC_V0_1_0 = "https://tent.io/types/info/basic/v0.1.0";
    }

    public static class PostTypes
    {
        public const string TYPE_ALBUMv010 = "https://tent.io/types/post/album/v0.1.0";
        public const string TYPE_ALBUMv020 = "https://tent.io/types/post/album/v0.2.0";
        public const string TYPE_DELETEv010 = "https://tent.io/types/post/delete/v0.1.0";
        public const string TYPE_DELETEv020 = "https://tent.io/types/post/delete/v0.2.0";
        public const string TYPE_ESSAYv010 = "https://tent.io/types/post/essay/v0.1.0";
        public const string TYPE_ESSAYv020 = "https://tent.io/types/post/essay/v0.2.0";
        public const string TYPE_MENTIONSv010 = "https://tent.io/types/post/mentions/v0.1.0";
        public const string TYPE_MENTIONSv020 = "https://tent.io/types/post/mentions/v0.2.0";
        public const string TYPE_PHOTOv010 = "https://tent.io/types/post/photo/v0.1.0";
        public const string TYPE_PHOTOv020 = "https://tent.io/types/post/photo/v0.2.0";
        public const string TYPE_PROFILEv010 = "https://tent.io/types/post/profile/v0.1.0";
        public const string TYPE_PROFILEv020 = "https://tent.io/types/post/profile/v0.2.0";
        public const string TYPE_REPOSTv010 = "https://tent.io/types/post/repost/v0.1.0";
        public const string TYPE_REPOSTv020 = "https://tent.io/types/post/repost/v0.2.0";
        public const string TYPE_STATUSv010 = "https://tent.io/types/post/status/v0.1.0";
        public const string TYPE_STATUSv020 = "https://tent.io/types/post/status/v0.2.0";
    }

    public static class Licenses
    {
        public const string LICENSE_CREATIVE_COMMONS = "http://creativecommons.org/licenses/by/3.0/";
        public const string LICENSE_GPL_2 = "http://www.gnu.org/licenses/gpl-2.0.html";
        public const string LICENSE_GPL_3 = "http://www.gnu.org/licenses/gpl-3.0.html";
        public const string LICENSE_GPL_NEWEST = "http://www.gnu.org/licenses/gpl.html";
        public const string LICENSE_AGPL_3 = "http://www.gnu.org/licenses/agpl-3.0.html";
        public const string LICENSE_AGPL_NEWEST = "http://www.gnu.org/licenses/agpl.html";
        public const string LICENSE_PRIVATE = "http://fakedomain.org/licenses/private.html";
        public const string LICENSE_LIMITED = "http://fakedomain.org/intended-parties-only.html";
    }

    public static class Miscellaneous
    {
        public const string MEDIA_TYPE = "application/vnd.tent.v0+json";
        public const string PROFILE_REL = "https://tent.io/rels/profile";
        public const string PROFILE_REL_WITH_REL = "rel=\"https://tent.io/rels/profile\"";
        public const string VERSION = "0.0.1";
        public const int NONCE_LENGTH = 6;
        public const string HEX_CHARSET = "0123456789abcdef";
    }
}
