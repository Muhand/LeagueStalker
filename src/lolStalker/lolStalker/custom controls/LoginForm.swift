//
//  LoginForm.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/1/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class LoginForm: UIView {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let form:UIView = {
        let view = UIView()
        // TODO: Delete the next line, it's helpful only in debug
        view.backgroundColor = UIColor.blue
        return view
    }()
    
    let logo: UIImageView = {
        let image = UIImageView()
        image.image = UIImage(named: "logo")
        image.contentMode = .scaleAspectFit
        image.layer.masksToBounds = true
        image.frame.size = CGSize(width: 208, height: 84)
        return image
    }()
    
    let emailField: UITextField = {
        let field = UITextField()
        field.backgroundColor = UIColor.green
        field.placeholder = "Email"
        return field
    }()
    
    let passwordField: UITextField = {
        let field = UITextField()
        field.backgroundColor = UIColor.red
        field.placeholder = "Password"
        return field
    }()
    
    let loginButton: UIButton = {
        let button = UIButton()
        button.backgroundColor = UIColor.magenta
        return button
    }()
    
    let signupButton: UIButton = {
        let button = UIButton()
        button.backgroundColor = UIColor.brown
        return button
    }()
    
    let forgotPasswordLabel: UILabel = {
        let label = UILabel()
        label.text = "Forgot password?"
        label.textColor = UIColor(hex: "#95989A")
        return label
    }()
    
    ////////// END OF CONTROLS /////////
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupView()
        setupLoginForm()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupView() {
        // TODO: Delete the next line, it's helpful only in debug
        self.backgroundColor = UIColor.yellow
        // 68.3658170915 came from the reference design on Adobe xd
        // Took the height on Adobe XD and figured it's percentage to the adobe XD height
        // and thats where 68.3658170915 came from
        self.frame.size = CGSize(width: UIScreen.main.bounds.width, height: (UIScreen.main.bounds.height*68.3658170915)/100)
        self.addSubview(form)
        self.addConstraintsWithFormat(format: "H:|-32-[v0]-32-|", views: form)
        self.addConstraintsWithFormat(format: "V:|[v0]|", views: form)
    }
    
    func setupLoginForm() {
        // MARK: Add subviews
        form.addSubview(self.logo)
        form.addSubview(emailField)
        form.addSubview(passwordField)
        form.addSubview(loginButton)
        form.addSubview(signupButton)
        form.addSubview(forgotPasswordLabel)
        
        
        // MARK: Constraints
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.logo)
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.emailField)
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.passwordField)
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.loginButton)
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.signupButton)
        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.forgotPasswordLabel)
        form.addConstraintsWithFormat(format: "V:|-15-[v0]-52-[v1]-26-[v2]-59-[v3]-12-[v4]-18-[v5]", views: self.logo, self.emailField, self.passwordField, self.loginButton, self.signupButton, self.forgotPasswordLabel)
    }
    
    
}
