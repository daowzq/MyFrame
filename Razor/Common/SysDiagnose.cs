using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Razor
{
    public sealed class SysDiagnotiseHelper
    {
        /// <summary>
        /// 检测性能类,包括GC的释放次数,
        /// 该实例对象被释放的时候会Console输出测试结果
        /// </summary>
        public sealed class OperationTimer : IDisposable
        {
            private Int64 m_startTime;
            private String m_text;
            private int m_collectioncount;
            public OperationTimer(string text)
            {
                PrepareForOpenation();
                m_text = text;
                m_collectioncount = GC.CollectionCount(0);
                m_startTime = Stopwatch.GetTimestamp(); //该类实例化时间
            }
            public void Dispose()
            {
                Console.WriteLine("{0,6:###.00} seconds (Gcs={1,3}) {2}", (Stopwatch.GetTimestamp() - m_startTime) /
                    (Double)Stopwatch.Frequency, GC.CollectionCount(0) - m_collectioncount, m_text);
            }
            private static void PrepareForOpenation()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();//挂起当前线程,直到处理终结器队列的线程清空该队列为止
                GC.Collect();
                //这里进行了两次Collect 调用
            }
        }
    }
}
