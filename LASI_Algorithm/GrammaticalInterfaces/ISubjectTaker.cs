﻿

namespace LASI.Algorithm
{
    public interface ISubjectTaker
    {
        void BindToSubject(IActionSubject verbSubject);
        IActionSubject BoundSubject {
            get;
            set;
        }
    }
}