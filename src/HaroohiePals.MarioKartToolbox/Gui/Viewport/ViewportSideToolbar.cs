﻿using HaroohiePals.Gui;
using HaroohiePals.Gui.Viewport;
using ImGuiNET;
using System.Numerics;

namespace HaroohiePals.MarioKartToolbox.Gui.Viewport;

internal class ViewportSideToolbar
{
    public void Draw(ViewportContext context, Gizmo gizmo)
    {
        float scale = ImGuiEx.GetUiScale();

        var padding = new Vector2(8, 8) * scale;

        float btnSize = 24 * scale;
        float spacing = 2 * scale;

        int items = 4;

        uint selectedColor = ImGui.GetColorU32(ImGuiCol.ButtonHovered) | 0xFF000000;

        ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, Vector2.Zero);
        var targetTool = gizmo.Tool;

        ImGui.SetNextWindowPos(ImGui.GetWindowPos() + ImGui.GetWindowContentRegionMin() + padding);
        if (ImGui.BeginChildFrame(ImGui.GetID("Tools"), new(btnSize + spacing, (btnSize + spacing) * items),
                ImGuiWindowFlags.NoBackground))
        {
            ImGui.SetCursorPosX(0);
            ImGui.SetCursorPosY(0);

            int i = 1;

            if (gizmo.Tool == Gizmo.GizmoTool.Draw)
                ImGui.PushStyleColor(ImGuiCol.Button, selectedColor);
            if (ImGui.Button($"{FontAwesome6.Pencil}##Draw", new(btnSize)))
                targetTool = Gizmo.GizmoTool.Draw;
            if (gizmo.Tool == Gizmo.GizmoTool.Draw)
                ImGui.PopStyleColor();

            ImGui.SetCursorPosY((btnSize + spacing) * i++);

            if (gizmo.Tool == Gizmo.GizmoTool.Translate)
                ImGui.PushStyleColor(ImGuiCol.Button, selectedColor);
            if (ImGui.Button($"{FontAwesome6.UpDownLeftRight}##Translate", new(btnSize)))
                targetTool = Gizmo.GizmoTool.Translate;
            if (gizmo.Tool == Gizmo.GizmoTool.Translate)
                ImGui.PopStyleColor();

            ImGui.SetCursorPosY((btnSize + spacing) * i++);

            if (gizmo.Tool == Gizmo.GizmoTool.Rotate)
                ImGui.PushStyleColor(ImGuiCol.Button, selectedColor);
            if (ImGui.Button($"{FontAwesome6.ArrowsRotate}##Rotate", new(btnSize)))
                targetTool = Gizmo.GizmoTool.Rotate;
            if (gizmo.Tool == Gizmo.GizmoTool.Rotate)
                ImGui.PopStyleColor();
            ImGui.SetCursorPosY((btnSize + spacing) * i++);

            if (gizmo.Tool == Gizmo.GizmoTool.Scale)
                ImGui.PushStyleColor(ImGuiCol.Button, selectedColor);
            if (ImGui.Button($"{FontAwesome6.UpRightAndDownLeftFromCenter}##Scale", new(btnSize)))
                targetTool = Gizmo.GizmoTool.Scale;
            if (gizmo.Tool == Gizmo.GizmoTool.Scale)
                ImGui.PopStyleColor();

            ImGui.EndChildFrame();
        }

        ImGui.PopStyleVar();

        gizmo.Tool = targetTool;
    }
}