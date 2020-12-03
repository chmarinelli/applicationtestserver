using System;

namespace TestServer.Core.Extensions
{
    public static class MemberInfoExtensions
    {
        public static string GetCleanNameFromDto(this Type memberInfo)
        {
            return memberInfo.Name.Replace("Dto", "");
        }
    }
}
