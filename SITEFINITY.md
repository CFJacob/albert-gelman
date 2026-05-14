# Albert Gelman Inc. — Sitefinity Integration

Production-ready Razor partials and Tailwind v4 CSS for the homepage,
built to drop straight into a Sitefinity v15.4 .NET Core Renderer project.

---

## File map

```
sitefinity/
├── app.css                 → Tailwind v4 entry. @theme inline tokens + components.
├── _Layout.cshtml          → Master layout (head, AG mark, header/footer, scripts)
├── _AGMark.cshtml          → Reusable inline SVG <symbol id="ag-mark"/>
├── _SectionHead.cshtml     → Shared 3/9 asymmetric section header
│
├── Header.cshtml           → Sticky site header widget
├── Hero.cshtml             → 01 Hero
├── WhoWeAre.cshtml         → 02 Who We Are (+ testimonial slider)
├── People.cshtml           → 03 People (horizontal scroll rail)
├── WhoWeServe.cshtml       → 04 Who We Serve (asymmetric 5-card grid)
├── Facts.cshtml            → 05 Facts (animated counters)
├── HowWeHelp.cshtml        → 06 How We Help (3×2 service grid)
├── WhyAGI.cshtml           → 07 Why AGI (closing brand statement)
├── SiteFooter.cshtml       → Site-wide footer
│
├── Index.cshtml            → Reference homepage assembly
└── ViewModels.cs           → All C# view models (one file, split before merging)
```

---

## Quick-start (drop-in path)

Assuming a typical Sitefinity .NET Core Renderer project structure:

1. **CSS** — copy `app.css` to your `ResourcePackages/AlbertGelman/assets/source/` folder, build with the Tailwind CLI:
   ```bash
   npx @tailwindcss/cli -i ./assets/source/app.css -o ./assets/dist/app.css --minify
   ```
   The `_Layout.cshtml` references `~/ResourcePackages/AlbertGelman/assets/dist/app.css`.

2. **Partials** — copy all `*.cshtml` to one of:
   - `Views/Shared/Components/...` (component-style widgets), or
   - `ResourcePackages/AlbertGelman/MVC/Views/Shared/` (resource-package widgets).

   `_Layout.cshtml`, `_AGMark.cshtml` and `_SectionHead.cshtml` belong in `Views/Shared/`.

3. **ViewModels** — split `ViewModels.cs` into one file per class under `ViewModels/`. Update the namespace if it differs from `AlbertGelman.Web.ViewModels`.

4. **Logo assets** — copy the four logo .webp files into `ResourcePackages/AlbertGelman/assets/`. `SiteFooter.cshtml` references `AG_Logo_rgb.webp`; the header uses the inline SVG mark.

5. **Page composition** — `Index.cshtml` shows the canonical homepage assembly. In production, register each section as a Sitefinity widget (see "Widget registration" below) so editors can drag/drop and reorder sections.

---

## Widget registration

Each section partial maps cleanly to a Sitefinity MVC widget. Example for `Hero.cshtml`:

```csharp
[ControllerToolboxItem(
    Name              = "AGHero",
    Title             = "AG · Hero",
    SectionName       = "AlbertGelman",
    CssClass          = "sfMvcIcn"
)]
public class HeroController : Controller
{
    public ActionResult Index()
    {
        var model = new HeroViewModel(); // pull from Sitefinity dynamic module
        return View("Hero", model);
    }
}
```

Repeat for `WhoWeAre`, `People`, `WhoWeServe`, `Facts`, `HowWeHelp`, `WhyAGI`, `Header`, `SiteFooter`.

For CMS-editable content, swap the default `ViewModel` properties for values fetched from Sitefinity dynamic content modules (e.g. via `IRestService` or `ContentItems` queries).

---

## Dependencies

External resources loaded by `_Layout.cshtml`:

| Library              | Purpose                          | CDN                                                                 |
|----------------------|----------------------------------|---------------------------------------------------------------------|
| Fraunces, Inter Tight, JetBrains Mono | Display, body, mono fonts | fonts.googleapis.com                                              |
| Iconify (iconify-icon) | Phosphor icons (`ph:` set)     | code.iconify.design                                                |
| GSAP 3.12 + ScrollTrigger | Refined motion                | cdnjs.cloudflare.com                                              |
| Alpine.js 3 + intersect | Reactivity                     | cdn.jsdelivr.net                                                  |

All scripts use `defer` to keep the critical rendering path clean.

In production, host these locally inside the resource package and apply `<link rel="preload">` for the variable font subset.

---

## Brand tokens (extracted from logo + brief)

```
--color-ink:           oklch(18% 0.05 264)   /* deep navy */
--color-ink-soft:      oklch(26% 0.055 264)
--color-jade:          oklch(56% 0.16 148)   /* brand green */
--color-jade-deep:     oklch(46% 0.15 148)
--color-amber:         oklch(82% 0.16 88)    /* reserved for awards <2% */
--color-paper:         oklch(98.5% 0.004 80) /* warm off-white */
--color-cream:         oklch(96.5% 0.016 82) /* warmth wash */
--color-mint:          oklch(96% 0.022 152)  /* Facts section wash */
--color-ash:           oklch(88% 0.006 240)  /* hairlines */
```

All are declared inside `@theme inline { … }` so Tailwind utilities work:
`bg-ink`, `text-jade`, `border-ash`, etc.

---

## Accessibility & performance targets

- **Contrast**: navy on cream 17.3:1 (AAA), jade-deep on cream/paper 5.1–5.2:1 (AA Large only — never body text).
- **Motion**: `prefers-reduced-motion: reduce` neutralises animation/transition durations and forces reveals to visible.
- **Semantic**: every section uses `<section>`, `<article>`, `<nav>`, `<header>`, `<footer>`; section headings have `aria-labelledby` referencing their visible h2 IDs.
- **Lazy-loaded**: all imagery loads with `loading="lazy"` except the hero (which gets `fetchpriority="high"`).
- **Target Lighthouse**: Performance ≥ 92, Accessibility 98, Best Practices 95, SEO 95.

---

## Outstanding decisions for client sign-off

These remain open per `design-rationale.md` (section 8):

1. Confirm hero headline — currently **"Senior Judgment. Right-Sized Support."**
2. Confirm/refine Facts #4–7 (esp. **0% senior turnover** — needs HR sign-off)
3. Supply real testimonial quotes (3 needed — currently anonymised placeholders)
4. Confirm People list (currently 6 — Albert, Bryan, plus 4 illustrative placeholders)
5. Adobe Fonts upgrade preference (Freight Display Pro + Acumin Pro vs the current Google stack)
6. Amber gold usage above-the-fold (currently zero — reserved for awards)
7. Placement of Insolvency Documents module (must remain per brief)
