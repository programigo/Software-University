﻿using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Execptions;

namespace BashSoft.IO.Commands
{
    [Alias("cdRel")]
    public class ChangePathRelativelyCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangePathRelativelyCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var relPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}