using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Helpers
{
    public static class CreateTagList
    {
        public static List<string> TagsList(List<string> tags)
        {
            string foo = "";
            foreach(var _tag in tags)
            {
                foo=string.Concat(foo, _tag);
            }
            List<string> tagsList = new List<string>();
            string tag = "";
            foreach (var element in foo)
            {
                tag = string.Concat(tag, element);
                if (element == ',' || element == ' ' || element == ';' || element == '.')
                {
                    tagsList.Add(tag);
                    tag = string.Empty;
                    continue;
                }
            }
            tagsList.Remove(",");
            return tagsList;
        }
    }
}
