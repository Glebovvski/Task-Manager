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
            foreach(var tag in tags)
            {
                foo=string.Concat(foo, tag);
            }
            List<string> tagsList = new List<string>();
            foreach (var element in foo)
            {
                string tag = "";
                while (element != ',' || element != ' ' || element != ';' || element != '.')
                {
                    tag = string.Concat(tag, element);
                }
                tagsList.Add(tag);
            }
            return tagsList;
        }
    }
}