using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Repositories
{
    public class MemberRepository : BaseRepository<Member>
    {
        protected override string GetFileName()
        {
            return "Members.txt";
        }
    }
}
