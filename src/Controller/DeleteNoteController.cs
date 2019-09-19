﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notes.DB;
using Notes.Infrastructure;
using Notes.Model;
using Notes.View;

namespace Notes.Controller
{
    public class DeleteNoteController : IController
    {
        private readonly IControllerFactory controllerFactory;
        private readonly IRepository repository;
        private readonly IView<Note> pageView;

        public DeleteNoteController(IControllerFactory controllerFactory, IRepository repository, IView<Note> pageView)
        {
            this.controllerFactory = controllerFactory;
            this.repository = repository;
            this.pageView = pageView;
            this.pageView.Info.AppName = "My Notes";
            this.pageView.Info.PageName = "Delete note by id";
        }

        public void Run()
        {
            pageView.Render();
        }

        public void Run(int id)
        {
            var result = repository.DeleteNode(id);
            pageView.Model = new Note { Id = result ? id : 0 };
            pageView.Render();
        }

        public void RunCommand(string command)
        {
            int commandId;
            int.TryParse(command, out commandId);
            if ((new[] { 0, 5 }).Contains(commandId))
            {
                var controller = controllerFactory.GetController(commandId);
                controller.Run();
            }
        }

    }
}
