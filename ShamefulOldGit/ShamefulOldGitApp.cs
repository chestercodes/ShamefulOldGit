﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using ShamefulOldGit.Actors;

namespace ShamefulOldGit
{
    public class ShamefulOldGitApp
    {
	    private readonly ActorSystem MyActorSystem;

		public ShamefulOldGitApp()
	    {
			MyActorSystem = ActorSystem.Create(ActorSelectionRouting.ActorSystemName);
		}

		public void Run(string[] args)
		{
			var repoCoord = MyActorSystem.ActorOf(
				Props.Create(
					() => new RepositoriesCoordinatorActor()), 
					ActorSelectionRouting.RepositoriesCoordinatorActorName);

			repoCoord.Tell(new RepositoriesCoordinatorActor.RepositoriesToReportOn(args));

			MyActorSystem.AwaitTermination();
		}
	}
}
