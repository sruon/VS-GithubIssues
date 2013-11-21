// Guids.cs
// MUST match guids.h
using System;

namespace sruon.GithubIssues
{
    static class GuidList
    {
        public const string guidVSPackage1PkgString = "99970367-21b0-4e53-946b-1af48371cdfd";
        public const string guidVSPackage1CmdSetString = "eed05d84-a9bd-453f-b4f9-4d97ff7ff0e8";
        public const string guidToolWindowPersistanceString = "53a4dafb-3976-4b6d-95c3-5533d0bee201";

        public static readonly Guid guidVSPackage1CmdSet = new Guid(guidVSPackage1CmdSetString);
    };
}