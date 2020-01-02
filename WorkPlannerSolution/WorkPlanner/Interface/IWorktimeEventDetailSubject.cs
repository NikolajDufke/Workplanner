using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner.Interface
{
    public interface IWorktimeEventDetailSubject
{
    void AttachSubscriber(IWorkTimeEventDetailObserver subscriber);
    void DetachSubscriber(IWorkTimeEventDetailObserver subscriber);
    void notify();
}

}
