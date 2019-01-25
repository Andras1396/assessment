package MvvmCross.Platforms.Android.Binding.Views;

import android.content.Context;
import android.support.annotation.Nullable;
import android.util.AttributeSet;
import android.widget.FrameLayout;
import android.widget.Spinner;

public class MvxFrameControl extends FrameLayout {
    public MvxFrameControl(Context context) {
        super(context);
    }

    public MvxFrameControl(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    public MvxFrameControl(Context context, @Nullable AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }
}
