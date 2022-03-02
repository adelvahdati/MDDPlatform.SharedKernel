using MDDPlatform.SharedKernel.Exceptions;

namespace MDDPlatform.SharedKernel.ActionResults
{
    public class TheAction : IActionStatus
    {
        public ActionStatus Status { get; }
        public string Message { get; } = string.Empty;

        protected TheAction(ActionStatus status, string message)
        {
            Status = status;

            if (string.IsNullOrEmpty(message))
                Message = string.Empty;
            else
                Message = message;
        }
        public static IActionStatus Failed(string error)
        {
            return new TheAction(ActionStatus.Failure, error);
        }
        public static IActionStatus IsDone(string message = "")
        {
            return new TheAction(ActionStatus.Success, message);
        }
        public static IActionResult<T> IsDone<T>(T result, string message = "")
        {
            return new TheActionResult<T>(result, ActionStatus.Success, message);
        }
        public static IActionResult<T> Failed<T>(string error)
        {
            return new TheActionResult<T>(default(T), ActionStatus.Failure, error);
        }
    }
    internal class TheActionResult<T> : IActionResult<T>
    {
        public ActionStatus Status { get; }
        public string Message { get; } = string.Empty;

        private readonly T? _result;
        public TheActionResult(T? result, ActionStatus status, string message = "")
        {
            _result = result;
            Status = status;

            if (string.IsNullOrEmpty(message))
                Message = string.Empty;
            else
                Message = message;
        }
        public T? Result
        {
            get
            {
                if(Status == ActionStatus.Failure)
                    throw new ActionNullResultException(Message);
                return _result;
            }
        }
    }

    public enum ActionStatus
    {
        Failure,
        Success
    }
    public interface IActionStatus{
        ActionStatus Status { get; }
        string Message { get; }
    }
    public interface IActionResult<T> : IActionStatus{
        public T? Result {get;}
    }

}