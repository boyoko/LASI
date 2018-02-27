﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LASI.Core.Heuristics.Binding.Experimental.SequentialPatterns;

namespace LASI.Core.Heuristics.Binding.Experimental.SequentialPatterns
{
    internal static class DeclarativeBinder
    {
        private static void Bind(Sentence sentence) => Example(sentence);

        static void Example(Sentence sentence)
        {
            sentence.Match()
                .WithContinuationMode(ContinuationMode.None)
                .When(sentence.Phrases.Count() > 2)
                .IgnoreOnce<IAdverbial, IDescriptor>()
                .Case((IEntity e1, IVerbal v, IEntity e2) =>
                {
                    v.BindSubject(e1);
                    v.BindDirectObject(e2);
                })
                .Case((IAdverbial a, IDescriptor d, IEntity e) =>
                {
                    e.BindDescriptor(d);
                    d.ModifyWith(a);
                })
                .Ignore<IAdverbial, IDescriptor>()
                .Case((IVerbal v1, IConjunctive c, IVerbal v2, IEntity e) =>
                {
                    c.JoinedLeft = v1;
                    c.JoinedRight = v2;
                    v1.BindDirectObject(e);
                    v2.BindDirectObject(e);
                })
                .Case((IEntity e1, IConjunctive c, IEntity e2, IVerbal v, IEntity e3, IPrepositional p1, IEntity e4) =>
                {
                    c.JoinedLeft = e1;
                    c.JoinedRight = e2;
                    v.BindSubject(e1);
                    v.BindSubject(e2);
                    v.BindDirectObject(e3);
                    v.BindIndirectObject(e4);
                })
                .Case((IEntity e1, IConjunctive c1, IEntity e2, IVerbal v, IEntity e3, IConjunctive c2, IEntity e4) =>
                {
                    c1.JoinedLeft = e1;
                    c1.JoinedRight = e2;
                    v.BindSubject(e1);
                    v.BindSubject(e2);
                    c2.JoinedLeft = e1;
                    c2.JoinedRight = e2;
                    v.BindDirectObject(e3);
                    v.BindDirectObject(e4);
                })
                .Case((IEntity e1, IVerbal v, IEntity e2, IConjunctive c, IEntity e3) =>
                {
                    v.BindSubject(e1);
                    c.JoinedLeft = e1;
                    c.JoinedRight = e2;
                    v.BindDirectObject(e2);
                    v.BindDirectObject(e3);
                })
                .Case((IEntity s, IVerbal v, IEntity o1, IEntity o2, SymbolPhrase p, IConjunctive c, IEntity o3) =>
                {
                    v.BindSubject(s);
                    c.JoinedLeft = p;
                    c.JoinedRight = o3;
                    v.BindDirectObject(o1);
                    v.BindDirectObject(o2);
                    v.BindDirectObject(o3);
                });
        }
    }
}

