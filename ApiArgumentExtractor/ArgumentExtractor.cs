using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiArgumentExtractor
{
    public class ArgumentExtractor
    {
        public string Extract(Dictionary<string, object> arguments)
        {
            bool hasArgsLeft = true;
            int index = 0;
            StringBuilder sb = new StringBuilder();

            while (hasArgsLeft)
            {

                var args = arguments.ElementAt(index);
                Type valueType = args.Value.GetType();

                if (valueType.IsGenericType)
                {
                    Type baseType = valueType.GetGenericTypeDefinition();
                    if (baseType == typeof(KeyValuePair<,>))
                    {
                        ArgumentExtractor newExtractor = new ArgumentExtractor();
                        var test = baseType.GetGenericArguments();
                        //sb.Append(newExtractor.Extract(baseType.GetGenericArguments()));
                    }
                }
                else
                {
                    sb.Append(Environment.NewLine);
                    sb.Append($"{args.Key}:\t{args.Value}");
                }

                index++;
            }

            return sb.ToString();
        }
    }
}
