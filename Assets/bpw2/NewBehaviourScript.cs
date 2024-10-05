using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InvertColorsPass : ScriptableRenderPass
{
    private Material _invertMaterial;

    private RenderTargetIdentifier _source;
    private RenderTargetHandle _temporaryRenderTarget;

    public InvertColorsPass(Material invertMaterial)
    {
        _invertMaterial = invertMaterial;
        _temporaryRenderTarget.Init("_TemporaryColorTexture");
    }

    public void Setup(RenderTargetIdentifier source)
    {
        _source = source;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        CommandBuffer cmd = CommandBufferPool.Get("Invert Colors");

        RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
        opaqueDesc.depthBufferBits = 0;

        cmd.GetTemporaryRT(_temporaryRenderTarget.id, opaqueDesc);

        // Blit from source to temp texture using the invert material
        Blit(cmd, _source, _temporaryRenderTarget.Identifier(), _invertMaterial);

        // Blit back from temp texture to source
        Blit(cmd, _temporaryRenderTarget.Identifier(), _source);

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    public override void FrameCleanup(CommandBuffer cmd)
    {
        if (_temporaryRenderTarget != RenderTargetHandle.CameraTarget)
        {
            cmd.ReleaseTemporaryRT(_temporaryRenderTarget.id);
        }
    }
}
