﻿using Notes.Controller;
using Notes.Infrastructure;
using Notes.Model;
using System;
using System.Collections.Generic;

namespace Notes.View
{
    public class ViewAllNotesPageView : PageView<Page<List<Note>>, List<Note>>
    {
        private readonly ViewAllController controller;

        public ViewAllNotesPageView(Page<List<Note>> info, List<Note> model, ViewAllController controller) : base(info, model)
        {
            this.controller = controller;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine($"Id\tTitle");
            Console.WriteLine($"==\t=====");
            foreach (var item in model)
            {
                Console.WriteLine($"{item.Id}\t{item.Title}");
            }
            Console.WriteLine("Input command: [0] - return to start, [5] - help");
            var command = Console.ReadLine();
            controller.RunCommand(command);
        }
    }
}
