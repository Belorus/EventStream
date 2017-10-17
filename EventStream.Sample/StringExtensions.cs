﻿using System;
using System.Text;

namespace EventStream.Generator
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string s)
        {
            var sb = new StringBuilder(s.ToLowerInvariant());

            int pos;
            while ((pos = sb.ToString().IndexOf('_')) != -1)
            {
                sb.Remove(pos, 1);
                sb.Replace(sb[pos], Char.ToUpperInvariant(sb[pos]), pos, 1);
            }

            sb[0] = Char.ToUpperInvariant(sb[0]);

            return sb.ToString();
        }

        public static string ToLowerCamelCase(this string s)
        {
            var sb = new StringBuilder(s.ToLowerInvariant());

            int pos;
            while ((pos = sb.ToString().IndexOf('_')) != -1)
            {
                sb.Remove(pos, 1);
                sb.Replace(sb[pos], Char.ToUpperInvariant(sb[pos]), pos, 1);
            }

            sb[0] = Char.ToLowerInvariant(sb[0]);

            return sb.ToString();
        }
    }
}