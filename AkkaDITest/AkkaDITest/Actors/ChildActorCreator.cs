﻿using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using Akka.DI.Core;

namespace AkkaDITest.Actors
{

    public interface IChildActorCreator
    {
        IActorRef Create<TActor>(IActorContext context, string name) where TActor : ActorBase;
        IActorRef Create<TActor>(IActorContext context) where TActor : ActorBase;
        Props GetProps<TActor>(IActorContext context) where TActor : ActorBase;
    }

    public class ChildActorCreator : IChildActorCreator
    {
        public IActorRef Create<TActor>(IActorContext context, string name) where TActor : ActorBase =>
            context.ActorOf(GetProps<TActor>(context), name);

        public IActorRef Create<TActor>(IActorContext context) where TActor : ActorBase => 
            Create<TActor>(context, null);

        public Props GetProps<TActor>(IActorContext context) where TActor : ActorBase => 
            context.DI().Props<TActor>();
    }
}
