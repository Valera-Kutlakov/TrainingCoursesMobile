//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingCoursesMobile.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class People
    {
        public People()
        {
            this.CoursePeople = new HashSet<CoursePeople>();
        }
    
        public int PeopleID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IDCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CoursePeople> CoursePeople { get; set; }
    }
}
