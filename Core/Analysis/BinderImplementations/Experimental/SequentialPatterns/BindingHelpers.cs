﻿using System;
using System.Collections.Generic;
using System.Linq;
using LASI.Core;
using LASI.Core.Analysis.BinderImplementations.Experimental.SequentialPatterns;
using LASI.Core.DocumentStructures;



namespace LASI.Core.Analysis.BinderImplementations.Experimental.SequentialPatterns
{


    static class BindingHelper
    {


        internal static bool Applicable<T1, T2, T3, TLexical>(this Action<T1, T2, T3> pattern, IReadOnlyList<TLexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where TLexical : class, ILexical {
            return elements.Count >= 3 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3;
        }
        internal static bool Applicable<T1, T2, T3, T4, TLexical>(this Action<T1, T2, T3, T4> pattern, IReadOnlyList<TLexical> elements)
                         where T1 : class, ILexical
                         where T2 : class, ILexical
                         where T3 : class, ILexical
                         where T4 : class, ILexical
                         where TLexical : class, ILexical {
            return elements.Count >= 4 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, TLexical>(this Action<T1, T2, T3, T4, T5> pattern, IReadOnlyList<TLexical> elements)
                        where T1 : class, ILexical
                        where T2 : class, ILexical
                        where T3 : class, ILexical
                        where T4 : class, ILexical
                        where T5 : class, ILexical
                        where TLexical : class, ILexical {
            return elements.Count >= 5 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5;

        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, TLexical>(this Action<T1, T2, T3, T4, T5, T6> pattern, IReadOnlyList<TLexical> elements)
                        where T1 : class, ILexical
                        where T2 : class, ILexical
                        where T3 : class, ILexical
                        where T4 : class, ILexical
                        where T5 : class, ILexical
                        where T6 : class, ILexical
                        where TLexical : class, ILexical {
            return elements.Count >= 6 &&
               elements[0] is T1 &&
               elements[1] is T2 &&
               elements[2] is T3 &&
               elements[3] is T4 &&
               elements[4] is T5 &&
               elements[5] is T6;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, TLexical>(this Action<T1, T2, T3, T4, T5, T6, T7> pattern, IReadOnlyList<TLexical> elements)
                       where T1 : class, ILexical
                       where T2 : class, ILexical
                       where T3 : class, ILexical
                       where T4 : class, ILexical
                       where T5 : class, ILexical
                       where T6 : class, ILexical
                       where T7 : class, ILexical
                       where TLexical : class, ILexical {
            return elements.Count >= 7 &&
              elements[0] is T1 &&
              elements[1] is T2 &&
              elements[2] is T3 &&
              elements[3] is T4 &&
              elements[4] is T5 &&
              elements[5] is T6 &&
              elements[6] is T7;
        }

        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, TLexical>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> pattern, IReadOnlyList<TLexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where T4 : class, ILexical
                      where T5 : class, ILexical
                      where T6 : class, ILexical
                      where T7 : class, ILexical
                      where T8 : class, ILexical
                      where TLexical : class, ILexical {
            return elements.Count >= 8 &&
              elements[0] is T1 &&
              elements[1] is T2 &&
              elements[2] is T3 &&
              elements[3] is T4 &&
              elements[4] is T5 &&
              elements[5] is T6 &&
              elements[6] is T7 &&
              elements[7] is T8;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLexical>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> pattern, IReadOnlyList<TLexical> elements)
                     where T1 : class, ILexical
                     where T2 : class, ILexical
                     where T3 : class, ILexical
                     where T4 : class, ILexical
                     where T5 : class, ILexical
                     where T6 : class, ILexical
                     where T7 : class, ILexical
                     where T8 : class, ILexical
                     where T9 : class, ILexical
                     where TLexical : class, ILexical {
            return elements.Count >= 8 &&
              elements[0] is T1 &&
              elements[1] is T2 &&
              elements[2] is T3 &&
              elements[3] is T4 &&
              elements[4] is T5 &&
              elements[5] is T6 &&
              elements[6] is T7 &&
              elements[7] is T8 &&
              elements[8] is T9;
        }

        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLexical>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pattern, IReadOnlyList<TLexical> elements)
                     where T1 : class, ILexical
                     where T2 : class, ILexical
                     where T3 : class, ILexical
                     where T4 : class, ILexical
                     where T5 : class, ILexical
                     where T6 : class, ILexical
                     where T7 : class, ILexical
                     where T8 : class, ILexical
                     where T9 : class, ILexical
                     where T10 : class, ILexical
                     where TLexical : class, ILexical {
            return elements.Count >= 8 &&
              elements[0] is T1 &&
              elements[1] is T2 &&
              elements[2] is T3 &&
              elements[3] is T4 &&
              elements[4] is T5 &&
              elements[5] is T6 &&
              elements[6] is T7 &&
              elements[7] is T8 &&
              elements[8] is T9 &&
              elements[9] is T10;
        }
        internal static bool Applicable<T1, T2, T3, TLexical>(this Func<T1, Func<T2, Action<T3>>> pattern, IReadOnlyList<TLexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where TLexical : class, ILexical {
            return elements.Count >= 3 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3;
        }
        internal static bool Applicable<T1, T2, T3, T4, TLexical>(this Func<T1, Func<T2, Func<T3, Action<T4>>>> pattern, IReadOnlyList<TLexical> elements)
                         where T1 : class, ILexical
                         where T2 : class, ILexical
                         where T3 : class, ILexical
                         where T4 : class, ILexical
                         where TLexical : class, ILexical {
            return elements.Count >= 4 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> pattern, IReadOnlyList<TLexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where T4 : class, ILexical
                      where T5 : class, ILexical
                      where TLexical : class, ILexical {
            return elements.Count >= 5 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Action<T6>>>>>> pattern, IReadOnlyList<TLexical> elements)
                   where T1 : class, ILexical
                   where T2 : class, ILexical
                   where T3 : class, ILexical
                   where T4 : class, ILexical
                   where T5 : class, ILexical
                   where T6 : class, ILexical
                   where TLexical : class, ILexical {
            return elements.Count == 6 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5 &&
                elements[5] is T6;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Action<T7>>>>>>> pattern, IReadOnlyList<TLexical> elements)
                  where T1 : class, ILexical
                  where T2 : class, ILexical
                  where T3 : class, ILexical
                  where T4 : class, ILexical
                  where T5 : class, ILexical
                  where T6 : class, ILexical
                  where T7 : class, ILexical
                  where TLexical : class, ILexical {
            return elements.Count == 7 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5 &&
                elements[5] is T6 &&
                elements[6] is T7;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Action<T8>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
                where T1 : class, ILexical
                where T2 : class, ILexical
                where T3 : class, ILexical
                where T4 : class, ILexical
                where T5 : class, ILexical
                where T6 : class, ILexical
                where T7 : class, ILexical
                where T8 : class, ILexical
                where TLexical : class, ILexical {
            return elements.Count == 8 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5 &&
                elements[5] is T6 &&
                elements[6] is T7 &&
                elements[7] is T8;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Action<T9>>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
              where T1 : class, ILexical
              where T2 : class, ILexical
              where T3 : class, ILexical
              where T4 : class, ILexical
              where T5 : class, ILexical
              where T6 : class, ILexical
              where T7 : class, ILexical
              where T8 : class, ILexical
              where T9 : class, ILexical
              where TLexical : class, ILexical {
            return elements.Count == 9 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5 &&
                elements[5] is T6 &&
                elements[6] is T7 &&
                elements[7] is T8 &&
                elements[8] is T9;
        }
        internal static bool Applicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical
            where T7 : class, ILexical
            where T8 : class, ILexical
            where T9 : class, ILexical
            where TLexical : class, ILexical {
            return elements.Count == 10 &&
                elements[0] is T1 &&
                elements[1] is T2 &&
                elements[2] is T3 &&
                elements[3] is T4 &&
                elements[4] is T5 &&
                elements[5] is T6 &&
                elements[6] is T7 &&
                elements[7] is T8 &&
                elements[8] is T9 &&
                elements[9] is T10;
        }



        internal static void Apply<T1, T2, T3, TLexical>(this Func<T1, Func<T2, Action<T3>>> pattern, IReadOnlyList<TLexical> elements)
                                  where T1 : class, ILexical
                                  where T2 : class, ILexical
                                  where T3 : class, ILexical
                                  where TLexical : class, ILexical {
            pattern(elements[0] as T1)(elements[1] as T2)(elements[2] as T3);
        }
        internal static void Apply<T1, T2, T3, T4, TLexical>(this Func<T1, Func<T2, Func<T3, Action<T4>>>> pattern, IReadOnlyList<TLexical> elements)
                         where T1 : class, ILexical
                         where T2 : class, ILexical
                         where T3 : class, ILexical
                         where T4 : class, ILexical
                         where TLexical : class, ILexical {
            pattern(
                    elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4);
        }
        internal static void Apply<T1, T2, T3, T4, T5, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> pattern, IReadOnlyList<TLexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where T4 : class, ILexical
                      where T5 : class, ILexical
                      where TLexical : class, ILexical {
            pattern(elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5);
        }
        internal static void Apply<T1, T2, T3, T4, T5, T6, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Action<T6>>>>>> pattern, IReadOnlyList<TLexical> elements)
                   where T1 : class, ILexical
                   where T2 : class, ILexical
                   where T3 : class, ILexical
                   where T4 : class, ILexical
                   where T5 : class, ILexical
                   where T6 : class, ILexical
                   where TLexical : class, ILexical {
            pattern(
               elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5)(
                elements[5] as T6);
        }
        internal static void Apply<T1, T2, T3, T4, T5, T6, T7, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Action<T7>>>>>>> pattern, IReadOnlyList<TLexical> elements)
                  where T1 : class, ILexical
                  where T2 : class, ILexical
                  where T3 : class, ILexical
                  where T4 : class, ILexical
                  where T5 : class, ILexical
                  where T6 : class, ILexical
                  where T7 : class, ILexical
                  where TLexical : class, ILexical {
            pattern(
                elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5)(
                elements[5] as T6)(
                elements[6] as T7);
        }
        internal static void Apply<T1, T2, T3, T4, T5, T6, T7, T8, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Action<T8>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
                where T1 : class, ILexical
                where T2 : class, ILexical
                where T3 : class, ILexical
                where T4 : class, ILexical
                where T5 : class, ILexical
                where T6 : class, ILexical
                where T7 : class, ILexical
                where T8 : class, ILexical
                where TLexical : class, ILexical {
            pattern(elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5)(
                elements[5] as T6)(
                elements[6] as T7)(
                elements[7] as T8);
        }
        internal static void Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Action<T9>>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
              where T1 : class, ILexical
              where T2 : class, ILexical
              where T3 : class, ILexical
              where T4 : class, ILexical
              where T5 : class, ILexical
              where T6 : class, ILexical
              where T7 : class, ILexical
              where T8 : class, ILexical
              where T9 : class, ILexical
              where TLexical : class, ILexical {
            pattern(elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5)(
                elements[5] as T6)(
                elements[6] as T7)(
                elements[7] as T8)(
                elements[8] as T9);
        }
        internal static void Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TLexical>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern, IReadOnlyList<TLexical> elements)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical
            where T7 : class, ILexical
            where T8 : class, ILexical
            where T9 : class, ILexical
            where T10 : class, ILexical {
            pattern(
                   elements[0] as T1)(
                elements[1] as T2)(
                elements[2] as T3)(
                elements[3] as T4)(
                elements[4] as T5)(
                elements[5] as T6)(
                elements[6] as T7)(
                elements[7] as T8)(
                elements[8] as T9)(
                elements[9] as T10);
        }

        internal static bool ApplyIfApplicable<T1, T2, T3>(this Func<T1, Func<T2, Action<T3>>> pattern, IReadOnlyList<ILexical> elements)
                                where T1 : class, ILexical
                                where T2 : class, ILexical
                                where T3 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;
        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4>(this Func<T1, Func<T2, Func<T3, Action<T4>>>> pattern, IReadOnlyList<ILexical> elements)
                         where T1 : class, ILexical
                         where T2 : class, ILexical
                         where T3 : class, ILexical
                         where T4 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5>(this Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> pattern, IReadOnlyList<ILexical> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where T4 : class, ILexical
                      where T5 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Action<T6>>>>>> pattern, IReadOnlyList<ILexical> elements)
                   where T1 : class, ILexical
                   where T2 : class, ILexical
                   where T3 : class, ILexical
                   where T4 : class, ILexical
                   where T5 : class, ILexical
                   where T6 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Action<T7>>>>>>> pattern, IReadOnlyList<ILexical> elements)
                  where T1 : class, ILexical
                  where T2 : class, ILexical
                  where T3 : class, ILexical
                  where T4 : class, ILexical
                  where T5 : class, ILexical
                  where T6 : class, ILexical
                  where T7 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Action<T8>>>>>>>> pattern, IReadOnlyList<ILexical> elements)
                where T1 : class, ILexical
                where T2 : class, ILexical
                where T3 : class, ILexical
                where T4 : class, ILexical
                where T5 : class, ILexical
                where T6 : class, ILexical
                where T7 : class, ILexical
                where T8 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Action<T9>>>>>>>>> pattern, IReadOnlyList<ILexical> elements)
              where T1 : class, ILexical
              where T2 : class, ILexical
              where T3 : class, ILexical
              where T4 : class, ILexical
              where T5 : class, ILexical
              where T6 : class, ILexical
              where T7 : class, ILexical
              where T8 : class, ILexical
              where T9 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern, IReadOnlyList<ILexical> elements)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical
            where T7 : class, ILexical
            where T8 : class, ILexical
            where T9 : class, ILexical
            where T10 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3>(this Func<T1, Func<T2, Action<T3>>> pattern, IReadOnlyList<Phrase> elements)
                               where T1 : class, ILexical
                               where T2 : class, ILexical
                               where T3 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;
        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4>(this Func<T1, Func<T2, Func<T3, Action<T4>>>> pattern, IReadOnlyList<Phrase> elements)
                         where T1 : class, ILexical
                         where T2 : class, ILexical
                         where T3 : class, ILexical
                         where T4 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5>(this Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> pattern, IReadOnlyList<Phrase> elements)
                      where T1 : class, ILexical
                      where T2 : class, ILexical
                      where T3 : class, ILexical
                      where T4 : class, ILexical
                      where T5 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Action<T6>>>>>> pattern, IReadOnlyList<Phrase> elements)
                   where T1 : class, ILexical
                   where T2 : class, ILexical
                   where T3 : class, ILexical
                   where T4 : class, ILexical
                   where T5 : class, ILexical
                   where T6 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Action<T7>>>>>>> pattern, IReadOnlyList<Phrase> elements)
                  where T1 : class, ILexical
                  where T2 : class, ILexical
                  where T3 : class, ILexical
                  where T4 : class, ILexical
                  where T5 : class, ILexical
                  where T6 : class, ILexical
                  where T7 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Action<T8>>>>>>>> pattern, IReadOnlyList<Phrase> elements)
                where T1 : class, ILexical
                where T2 : class, ILexical
                where T3 : class, ILexical
                where T4 : class, ILexical
                where T5 : class, ILexical
                where T6 : class, ILexical
                where T7 : class, ILexical
                where T8 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Action<T9>>>>>>>>> pattern, IReadOnlyList<Phrase> elements)
              where T1 : class, ILexical
              where T2 : class, ILexical
              where T3 : class, ILexical
              where T4 : class, ILexical
              where T5 : class, ILexical
              where T6 : class, ILexical
              where T7 : class, ILexical
              where T8 : class, ILexical
              where T9 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }
        internal static bool ApplyIfApplicable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern, IReadOnlyList<Phrase> elements)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical
            where T7 : class, ILexical
            where T8 : class, ILexical
            where T9 : class, ILexical
            where T10 : class, ILexical {
            var r = pattern.Applicable(elements);
            if (r)
                pattern.Apply(elements);
            return r;

        }

    }
    internal static class Matcher
    {
        internal static SentenceMatch Match(this Sentence sentence) {
            return new SentenceMatch(sentence);
        }
    }
    public partial class SentenceMatch(private Sentence value)
    {
        private bool predicateSucceded;
        private bool guarded;
        List<Func<ILexical, bool>> predicates = new List<Func<ILexical, bool>>();
        Func<Sentence, IEnumerable<ILexical>> test {
            get {

                return val => from v in val.Phrases where predicates.All(f => f(v)) select v;
            }
        }
        protected IReadOnlyList<ILexical> Values { get { return test(value).ToList(); } }
        protected bool Accepted { get; set; }

        public SentenceMatch TryPath<T1, T2, T3>(Action<T1, T2, T3> pattern) where T1 : class, ILexical where T2 : class, ILexical where T3 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4>(Action<T1, T2, T3, T4> pattern)
            where T1 : class, ILexical where T2 : class, ILexical
            where T3 : class, ILexical where T4 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> pattern)
        where T1 : class, ILexical
        where T2 : class, ILexical
        where T3 : class, ILexical
        where T4 : class, ILexical
        where T5 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> pattern)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5, Values[5] as T6);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> pattern)
        where T1 : class, ILexical
        where T2 : class, ILexical
        where T3 : class, ILexical
        where T4 : class, ILexical
        where T5 : class, ILexical
        where T6 : class, ILexical
        where T7 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5, Values[5] as T6, Values[6] as T7);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> pattern)
        where T1 : class, ILexical
        where T2 : class, ILexical
        where T3 : class, ILexical
        where T4 : class, ILexical
        where T5 : class, ILexical
        where T6 : class, ILexical
        where T7 : class, ILexical
        where T8 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5, Values[5] as T6, Values[6] as T7, Values[7] as T8);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> pattern)
        where T1 : class, ILexical
        where T2 : class, ILexical
        where T3 : class, ILexical
        where T4 : class, ILexical
        where T5 : class, ILexical
        where T6 : class, ILexical
        where T7 : class, ILexical
        where T8 : class, ILexical
        where T9 : class, ILexical {

            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5, Values[5] as T6, Values[6] as T7, Values[7] as T8, Values[8] as T9);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> pattern)
        where T1 : class, ILexical
        where T2 : class, ILexical
        where T3 : class, ILexical
        where T4 : class, ILexical
        where T5 : class, ILexical
        where T6 : class, ILexical
        where T7 : class, ILexical
        where T8 : class, ILexical
        where T9 : class, ILexical
        where T10 : class, ILexical {
            return CheckGuard(() => {
                Accepted = pattern.Applicable(Values);
                if (Accepted)
                    pattern(Values[0] as T1, Values[1] as T2, Values[2] as T3, Values[3] as T4, Values[4] as T5, Values[5] as T6, Values[6] as T7, Values[7] as T8, Values[8] as T9, Values[9] as T10);
            });
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern)
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical
            where T6 : class, ILexical
            where T7 : class, ILexical
            where T8 : class, ILexical
            where T9 : class, ILexical
            where T10 : class, ILexical
            where T11 : class, ILexical
            where T12 : class, ILexical
            where T13 : class, ILexical
            where T14 : class, ILexical
            where T15 : class, ILexical
            where T16 : class, ILexical
            where T17 : class, ILexical
            where T18 : class, ILexical
            where T19 : class, ILexical
            where T20 : class, ILexical {
            Accepted = pattern.ApplyIfApplicable(Values.ToList());
            return this;
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern)
          where T1 : class, ILexical
          where T2 : class, ILexical
          where T3 : class, ILexical
          where T4 : class, ILexical
          where T5 : class, ILexical
          where T6 : class, ILexical
          where T7 : class, ILexical
          where T8 : class, ILexical
          where T9 : class, ILexical
          where T10 : class, ILexical
          where T11 : class, ILexical
          where T12 : class, ILexical
          where T13 : class, ILexical
          where T14 : class, ILexical
          where T15 : class, ILexical
          where T16 : class, ILexical
          where T17 : class, ILexical
          where T18 : class, ILexical
          where T19 : class, ILexical {
            Accepted = pattern.ApplyIfApplicable(Values.ToList());
            return this;
        }
        public SentenceMatch TryPath<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Action<T10>>>>>>>>>> pattern)
         where T1 : class, ILexical
         where T2 : class, ILexical
         where T3 : class, ILexical
         where T4 : class, ILexical
         where T5 : class, ILexical
         where T6 : class, ILexical
         where T7 : class, ILexical
         where T8 : class, ILexical
         where T9 : class, ILexical
         where T10 : class, ILexical
         where T11 : class, ILexical
         where T12 : class, ILexical
         where T13 : class, ILexical
         where T14 : class, ILexical
         where T15 : class, ILexical
         where T16 : class, ILexical
         where T17 : class, ILexical
         where T18 : class, ILexical {
            Accepted = pattern.ApplyIfApplicable(Values.ToList());
            return this;
        }


        public SentenceMatch When(bool condition) {
            predicateSucceded = condition;
            return this;
        }
        public SentenceMatch When(Func<bool> condition) {
            predicateSucceded = condition();
            guarded = true;
            return this;
        }
        private SentenceMatch CheckGuard(Action onSuccess) {
            if (!Accepted && guarded && predicateSucceded) { onSuccess(); guarded = false; }
            return this;
        }

        public SentenceMatch FilterAll<T1>()
            where T1 : class, ILexical {
            predicates.Add(v => !(v is T1));
            return this;
        }
        public SentenceMatch FilterAll<T1, T2>()
            where T1 : class, ILexical
            where T2 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2));
            return this;
        }
        public SentenceMatch FilterAll<T1, T2, T3>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3));
            return this;
        }
        public SentenceMatch FilterAll<T1, T2, T3, T4>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3 || v is T4));
            return this;
        }
        public SentenceMatch FilterAll<T1, T2, T3, T4, T5>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3 || v is T4 || v is T5));
            return this;
        }
        public SentenceMatch FilterAll(Func<ILexical, bool> predicate) {
            predicates.Add(predicate);
            return this;
        }
        public SentenceMatch FilterOnce<T1>()
       where T1 : class, ILexical {
            predicates.Add(v => !(v is T1));
            return this;
        }
        public SentenceMatch FilterOnce<T1, T2>()
            where T1 : class, ILexical
            where T2 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2));
            return this;
        }
        public SentenceMatch FilterOnce<T1, T2, T3>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3));
            return this;
        }
        public SentenceMatch FilterOnce<T1, T2, T3, T4>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3 || v is T4));
            return this;
        }
        public SentenceMatch FilterOnce<T1, T2, T3, T4, T5>()
            where T1 : class, ILexical
            where T2 : class, ILexical
            where T3 : class, ILexical
            where T4 : class, ILexical
            where T5 : class, ILexical {
            predicates.Add(v => !(v is T1 || v is T2 || v is T3 || v is T4 || v is T5));
            return this;
        }
        public SentenceMatch FilterOnce(Func<ILexical, bool> predicate) {
            predicates.Add(predicate);
            return this;
        }
    }



    class Pattern
    {
        void BindSentence(Sentence s) {
            // wrap the sentence with a match that tries each path
            s.Match()
                .FilterOnce<IDescriptor>() // Adjectivals which appear within the attempted paths will be ignored.
                .When(s.Phrases.OfVerbPhrase().Any()) //just example of an arbitrary condition to check.
            .TryPath(
                (IEntity e1, IConjunctive c1, IEntity e2, IVerbal v1, IEntity e3, IPrepositional p1, IEntity e4) => {
                    c1.JoinedLeft = e1;
                    c1.JoinedRight = e2;
                    v1.BindSubject(e1);
                    v1.BindSubject(e2);
                    v1.BindDirectObject(e3);
                    v1.BindIndirectObject(e4);

                });

        }
    }
}






namespace LASI.Core.Analysis.BinderImplementations.Experimental.SequentialPatterns
{
    static class ListExtensions
    {
        public static List<T> Take<T>(this List<T> source, int count) {
            return source.GetRange(0, count);
        }
        public static List<T> Skip<T>(this List<T> source, int count) {
            try {
                return source.GetRange(count, source.Count);
            }
            catch (ArgumentException) {
                return new List<T>();
            }
        }

    }

}