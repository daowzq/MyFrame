using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

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

        #region GC代龄回收
        internal static class GCBeepDemo
        {
            public static void Go()
            {
                // Register a callback method to be invoked whenever a GC occurs. 
                SysDiagnotiseHelper.GCNotification.GCDone += g => Console.Beep(g == 0 ? 800 : 8000, 200);
                var l = new List<Object>();
                // Construct a lot of 100-byte objects.
                for (Int32 x = 0; x < 500000; x++)
                {
                    Console.WriteLine(x);
                    Byte[] b = new Byte[100];
                    l.Add(b);
                }
            }
        }

        public static class GCNotification
        {
            private static Action<int> s_gcDone = null;  //事件的字段

            public static event Action<int> GCDone
            {
                add
                {
                    //如果之前没有登记的委托,就开始通知
                    if (s_gcDone == null)
                    {
                        new GenObject(0);
                        new GenObject(2);
                    }
                    s_gcDone += value;
                }
                remove { s_gcDone -= value; }
            }

            private sealed class GenObject
            {
                private int m_generation;
                public GenObject(int generation)
                {
                    m_generation = generation;
                }

                ~GenObject()//这是Finalize 方法
                {
                    //如果这个对象在我们希望的(或更高)代中
                    //就通知委托一次刚刚完成
                    if (GC.GetGeneration(this) >= m_generation)
                    {
                        Action<int> temp = Interlocked.CompareExchange(ref s_gcDone, null, null);
                        if (temp != null)
                        {
                            temp(m_generation);
                        }
                    }

                    //如果至少还有一个已登记的委托,而且AppDomain 并非卸载
                    //而且进程并非关闭,就继续报告通知
                    if ((s_gcDone != null) && !AppDomain.CurrentDomain.IsFinalizingForUnload()
                        && !Environment.HasShutdownStarted)
                    {

                        //对于第0代,创建一个新对象;对于第2代,复活对象
                        //是第二代在下次回收时,GC会再次调用Finalize
                        if (m_generation == 0) new GenObject(0);
                        else GC.ReRegisterForFinalize(this);
                    }
                    else
                    {
                        //放过对象,让其被回收
                    }
                }
            }
        }

        #endregion
    }
}
