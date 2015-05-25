using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class ClusterTest : TestBase
    {
        [Test]
        public void Cluster_SetLink_SetsLink()
        {
            // given:
            var cluster = new Cluster("");
            var node = new Node("");

            // require:
            Assert.AreEqual(0, cluster.GetSrcObjectCount());
            Assert.AreEqual(0, cluster.GetDstObjectCount());
            Assert.Null(cluster.GetLink());

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(0, node.GetDstObjectCount());

            // when:
            cluster.SetLink(node);

            // then:
            Assert.AreEqual(1, cluster.GetSrcObjectCount());
            Assert.AreSame(node, cluster.GetSrcObject(0));
            Assert.AreEqual(0, cluster.GetDstObjectCount());
            Assert.AreSame(node, cluster.GetLink());

            Assert.AreEqual(0, node.GetSrcObjectCount());
            Assert.AreEqual(1, node.GetDstObjectCount());
            Assert.AreSame(cluster, node.GetDstObject(0));
        }
    }
}