using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace de.fhb.oll.mediacategorizer.edn
{
    public class EdnWriter
    {
        private readonly TextWriter w;

        private int indent = 0;
        private const string INDENT = "  ";

        public EdnWriter(TextWriter w)
        {
            this.w = w;
        }

        private void Indent()
        {
            w.Write(string.Concat(Enumerable.Repeat(INDENT, indent)));
        }

        public void WriteVector(IEnumerable items, bool oneItemPerLine = false)
        {
            w.Write("[");
            indent += 1;
            var first = true;
            foreach (var item in items)
            {
                if (oneItemPerLine)
                {
                    w.Write(Environment.NewLine);
                    Indent();
                }
                else if (!first)
                {
                    w.Write(" ");
                }
                WriteObject(item);
                if (first)
                {
                    first = false;
                }
            }
            indent -= 1;
            if (oneItemPerLine)
            {
                w.Write(Environment.NewLine);
                Indent();
            }
            w.Write("]");
        }

        public void WriteMap(IEnumerable<KeyValuePair<object, object>> pairs, bool onePairPerLine = true)
        {
            w.Write("{");
            indent += 1;
            var first = true;
            foreach (var pair in pairs)
            {
                if (onePairPerLine)
                {
                    w.Write(Environment.NewLine);
                    Indent();
                }
                else if (!first)
                {
                    w.Write(", ");
                }
                WriteObject(pair.Key);
                w.Write(" ");
                WriteObject(pair.Value);
                if (first)
                {
                    first = false;
                }
            }
            indent -= 1;
            if (onePairPerLine)
            {
                w.Write(Environment.NewLine);
                Indent();
            }
            w.Write("}");
        }

        public void WriteMap(IEnumerable pairs, bool onePairPerLine = true)
        {
            WriteMap(ConvertPairSequence(pairs), onePairPerLine);
        }

        private static IEnumerable<KeyValuePair<object, object>>  ConvertPairSequence(IEnumerable pairs)
        {
            object key = null;
            var isValue = false;
            foreach (var v in pairs)
            {
                if (isValue)
                {
                    yield return new KeyValuePair<object, object>(key, v);
                }
                else
                {
                    key = v;
                }
                isValue = !isValue;
            }
        }

        public void WriteObject(object o)
        {
            if (o == null)
            {
                w.Write("nil");
                return;
            }

            var ednWritable = o as IEdnWritable;
            if (ednWritable != null)
            {
                ednWritable.WriteTo(this);
                return;
            }

            if (o is Keyword)
            {
                w.Write(o.ToString());
                return;
            }

            if (o is bool)
            {
                w.Write((bool)o ? "true" : "false");
                return;
            }
            if (o is byte)
            {
                w.Write(((byte)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is sbyte)
            {
                w.Write(((sbyte)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is ushort)
            {
                w.Write(((ushort)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is short)
            {
                w.Write(((short)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is uint)
            {
                w.Write(((uint)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is int)
            {
                w.Write(((int)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is ulong)
            {
                w.Write(((ulong)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is long)
            {
                w.Write(((long)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is float)
            {
                w.Write(((float)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is double)
            {
                w.Write(((double)o).ToString(CultureInfo.InvariantCulture));
                return;
            }
            if (o is decimal)
            {
                w.Write(((decimal)o).ToString(CultureInfo.InvariantCulture) + "M");
                return;
            }

            var str = o as string;
            if (str != null)
            {
                w.Write("\"" + EscapeString(str) + "\"");
                return;
            }
        }

        private static string EscapeString(string str)
        {
            return str
                .Replace("\r", @"\r")
                .Replace("\n", @"\n")
                .Replace("\t", @"\t")
                .Replace("\"", @"\")
                .Replace(@"\", @"\\");
        }
    }
}