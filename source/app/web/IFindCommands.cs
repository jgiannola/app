﻿namespace app.web
{
  public interface IFindCommands
  {
    IRunOneRequest get_the_command_that_can_run(IContainRequestDetails the_request);
  }
}