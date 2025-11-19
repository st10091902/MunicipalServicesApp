using System;

namespace MunicipalServicesApp
{
    public class BstNode
    {
        public ServiceRequest Value;
        public BstNode Left, Right;
        public BstNode(ServiceRequest v) { Value = v; }
    }

    public class BstByRequestNo
    {
        public BstNode Root;

        public void Insert(ServiceRequest r)
        {
            Root = Insert(Root, r);
        }

        private BstNode Insert(BstNode n, ServiceRequest r)
        {
            if (n == null) return new BstNode(r);
            if (r.RequestNo < n.Value.RequestNo) n.Left = Insert(n.Left, r);
            else if (r.RequestNo > n.Value.RequestNo) n.Right = Insert(n.Right, r);
            else n.Value = r; // replace
            return n;
        }

        public ServiceRequest Find(int requestNo)
        {
            var n = Root;
            while (n != null)
            {
                if (requestNo < n.Value.RequestNo) n = n.Left;
                else if (requestNo > n.Value.RequestNo) n = n.Right;
                else return n.Value;
            }
            return null;
        }
    }
}
