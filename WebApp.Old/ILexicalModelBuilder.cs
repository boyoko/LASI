﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LASI.Core;
using LASI.WebApp.Old.Models.Lexical;

namespace LASI.WebApp.Old
{
	interface ILexicalModelBuilder<in TLexical, out TModel>
		where TLexical : class, ILexical
		where TModel : class, ILexicalModel<TLexical>
	{
		TModel BuildFor<TFor>(TLexical lexical) where TFor : class, ILexical;
	}
}